using AircraftFactoryBusinessLogic.BindingModels;
using AircraftFactoryBusinessLogic.Interfaces;
using AircraftFactoryBusinessLogic.ViewModels;
using AircraftFactoryFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AircraftFactoryFileImplement.Implements
{
    public class MessageInfoStorage : IMessageInfoStorage
    {
        private readonly FileDataListSingleton source;

        public MessageInfoStorage()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public List<MessageInfoViewModel> GetFullList() => source.MessageInfoes.Select(CreateModel).ToList();
        public List<MessageInfoViewModel> GetFilteredList(MessageInfoBindingModel model) => model == null ?
            source.MessageInfoes.Where(rec => (model.ClientId.HasValue && rec.ClientId == model.ClientId)
            || (!model.ClientId.HasValue && rec.DateDelivery.Date == model.DateDelivery.Date))
            .Select(CreateModel).ToList() :
            null;
        public void Insert(MessageInfoBindingModel model)
        {
            if (model == null)
            {
                return;
            }
            source.MessageInfoes.Add(CreateModel(model, new MessageInfo()));
        }

        private MessageInfo CreateModel(MessageInfoBindingModel model, MessageInfo message)
        {
            message.MessageId = model.MessageId;
            message.SenderName = source.Clients.FirstOrDefault(rec => rec.Id == model.ClientId)?.FIO;
            message.DateDelivery = model.DateDelivery;
            message.Subject = model.Subject;
            message.Body = model.Body;
            return message;
        }

        private MessageInfoViewModel CreateModel(MessageInfo message) => new MessageInfoViewModel
        {
            MessageId = message.MessageId,
            SenderName = message.SenderName,
            DateDelivery = message.DateDelivery,
            Subject = message.Subject,
            Body = message.Body,
        };
    }
}
