﻿namespace Divstack.Company.Estimation.Tool.Notifications.Push.Valuations.Persistance.DataAccess;

using Domain;
using MongoDB.Bson.Serialization;

internal static class NotificationPersistanceConfiguration
{
    internal static void Configure()
    {
        BsonClassMap.RegisterClassMap<Notification>(classMap =>
        {
            classMap.MapIdProperty(notification => notification.Id).SetIsRequired(true);
            classMap.MapProperty(notification => notification.ValuationId).SetIsRequired(true);
            classMap.MapProperty(notification => notification.MarkedAsRead).SetIsRequired(true);
            classMap.MapProperty(notification => notification.EventDate).SetIsRequired(true);
            classMap.MapProperty(notification => notification.Type).SetIsRequired(true);
            classMap.SetIgnoreExtraElements(true);
        });
    }
}