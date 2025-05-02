using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

#if UNITY_ANDROID
using Unity.Notifications.Android;
using UnityEngine.Android;
#endif

public class NotificationSimple : MonoBehaviour
{
    public static NotificationSimple Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    private const string idCanal = "canalNotificacion";

    private void Start()
    {
#if UNITY_ANDROID
        RequestAuthorization();
        RegisterNotificationChannel();
#endif
    }

    public void SendNotification(string title, string text, int fireTimeInHours)
    {
#if UNITY_ANDROID
        AndroidNotification notification = new AndroidNotification();
        notification.Title = title;
        notification.Text = text;
        notification.FireTime = DateTime.Now.AddHours(fireTimeInHours);
        notification.SmallIcon = "icon_0";
        notification.LargeIcon = "icon_1";

        AndroidNotificationCenter.SendNotification(notification, "default_channel");
#endif
    }
    public void SendHighScoreNotification(string title, string text, int fireTimeInHours)
    {
#if UNITY_ANDROID
        AndroidNotification notification = new AndroidNotification();
        notification.Title = title;
        notification.Text = text;
        notification.FireTime = DateTime.Now.AddHours(fireTimeInHours);
        notification.SmallIcon = "icon_0";
        notification.LargeIcon = "hsicon_1";

        AndroidNotificationCenter.SendNotification(notification, "default_channel");
#endif
    }

#if UNITY_ANDROID
    public void RequestAuthorization()
    {
        if (!Permission.HasUserAuthorizedPermission("android.permission.POST_NOTIFICATIONS"))
        {
            Permission.RequestUserPermission("android.permission.POST_NOTIFICATIONS");
        }
    }

    public void RegisterNotificationChannel()
    {
        AndroidNotificationChannel channel = new AndroidNotificationChannel
        {
            Id = "default_channel",
            Name = "Default",
            Importance = Importance.Default,
            Description = "Notifications"
        };

        AndroidNotificationCenter.RegisterNotificationChannel(channel);
    }
#endif
}

