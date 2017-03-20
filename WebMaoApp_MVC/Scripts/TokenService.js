app.service("TokenService", function ($http) {
    this.postMensaje = function (obj, Token) {
        var notificacion = {
            notification: {
                title: obj.title,
                body: obj.body,
                sound: "default",
                click_action: "FCM_PLUGIN_ACTIVITY",
                icon: "fcm_push_icon"
            },
            data: {
                title: obj.title,
                mensaje_foreground: obj.body
            },
            to: Token,
            priority: "high"
        };
        var pet = {
            method: 'POST',
            url: 'https://fcm.googleapis.com/fcm/send',
            headers: {
                'Content-Type': "application/json",
                'Authorization': 'key=AAAAKYgAco8:APA91bFGvrYPDGlT3ECKTXaD6oratzDr5b9QyjUjgoY6q-C4wdobd7O-rRLVpI7gOcAP9-elx9lcAs8qD-1DD0Hghi3sqbQkcp3D835YfcaAA9-f5mUY-Q3BgY0JVmuT27swuYMIBHaJBq4S9DZYvcOuhUVH584-wQ'
            },
            data: JSON.stringify(notificacion)
        };
        var req = $http(pet);
        return req;
    };
    this.getDispositivos = function () {
        var req = $http.get("/api/Token/");
        return req;
    };
});