using AircraftFactoryBusinessLogic.BindingModels;
using AircraftFactoryBusinessLogic.BusinessLogics;
using AircraftFactoryBusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AircraftFactoryRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ClientLogic _clientLogic;
        private readonly MailLogic _mailLogic;
        private readonly int _passwordMaxLength = 50;
        private readonly int _passwordMinLength = 10;
        public ClientController(ClientLogic logic, MailLogic mailLogic)
        {
            _clientLogic = logic;
            _mailLogic = mailLogic;
        }
        [HttpGet]
        [HttpGet]
        public ClientViewModel Login(string login, string password) => _clientLogic.Read(new ClientBindingModel { Email = login, Password = password })?[0];
        [HttpGet]
        public List<MessageInfoViewModel> GetMessages(int clientId) => _mailLogic.Read(new MessageInfoBindingModel { ClientId = clientId });
        [HttpPost]
        public void Register(ClientBindingModel model) => _clientLogic.CreateOrUpdate(model);
        [HttpPost]
        public void UpdateData(ClientBindingModel model)
        {
            CheckData(model);
            _clientLogic.CreateOrUpdate(model);
        }
        private void CheckData(ClientBindingModel model)
        {
            if (!Regex.IsMatch(model.Email, @"^([a-z0-9_-]+\.)*[a-z0-9_-]+@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$"))
            {
                throw new Exception("� �������� ������ ����� ������� ������ ����");
            }
            if (model.Password.Length > _passwordMaxLength || model.Password.Length < _passwordMinLength || !Regex.IsMatch(model.Password,
             @"^((\w+\d+\W+)|(\w+\W+\d+)|(\d+\w+\W+)|(\d+\W+\w+)|(\W+\w+\d+)|(\W+\d+\w+))[\w\d\W]*$"))
            {
                throw new Exception($"������ ������ �� {_passwordMinLength} �� { _passwordMaxLength } ������ ���� � �� ����, ���� � ����������� �������� ������ ��������");
            }
        }
    }
}
