﻿var notificationSettings;

$("#notificationsettings").click(function () {
    swal({
        title: 'Persoonlijke instellingen',
        html:
        '<div id="settingswindow">' +
        '<ul id="notificationlist">' +
        '<li>Notificaties ontvangen over: </li>' +
        '<li><input id="notif_team" name="Team" type="checkbox" /> <label for="Team"> Team updates</label></li>' +
        '<li><input id="notif_masterincidenten" name="Masterincidenten" type="checkbox" /> <label for="Masterincidenten"> Master incident updates</label></li>' +
        '<li><input id="notif_sos" name="Sos" type="checkbox" /> <label for="Sos"> SOS updates</label></li>' +
        '<li><input id="notif_meldingen" name="Meldingen" type="checkbox" /> <label for="Meldingen"> Melding updates</label></li>' +
        '<li><input id="notif_chat" name="Chat" type="checkbox" /> <label for="Chat"> Chat updates</label></li>' +
        '<span id="notificationsnotsupported" class="invisible"><i class="fa fa-bell-slash" aria-hidden="true"></i> Je browser ondersteund geen desktop notificaties </span>' +
        '<span id="notificationssupported" class="invisible"><i class="fa fa-bell" aria-hidden="true"></i> Je browser ondersteund desktop notificaties! </span>' +
        '</ul>' +
        '<button type="button" class="btn btn-default" id="reset-layout-button">Reset dashboard layout </button>' +
        '</div>',
        showCancelButton: true,
        confirmButtonText: "Opslaan",
        onOpen: function () {
            $("#notif_team").prop("checked", notificationSettings["Team"]);
            $("#notif_masterincidenten").prop("checked", notificationSettings["Masterincidenten"]);
            $("#notif_sos").prop("checked", notificationSettings["Sos"]);
            $("#notif_meldingen").prop("checked", notificationSettings["Meldingen"]);
            $("#notif_chat").prop("checked", notificationSettings["Chat"]);

            //Don't allow the user to set the properties if their browser doesn't support notifications
            if (!("Notification" in window)) {
                $("#notificationlist").prop("disabled", true);
                $("#settingswindow li").css("color", "lightgray");
                $("#notificationsnotsupported").removeClass("invisible");
            } else {
                Notification.requestPermission();
                $("#notificationssupported").removeClass("invisible");
            }
        }
    }).then(function () {
        saveNotificationSettings();
    });
});

$(document).on('click', "#reset-layout-button", function () {
    resetGridLayout();
});

var saveNotificationSettings = function () {

    notificationSettings =
        {
            "Team" : $("#notif_team").is(':checked'),
            "Masterincidenten": $("#notif_masterincidenten").is(':checked'),
            "Sos": $("#notif_sos").is(':checked'),
            "Meldingen": $("#notif_meldingen").is(':checked'),
            "Chat": $("#notif_chat").is(':checked')
        }

    sendUpdatedNotificationsettings(JSON.stringify(notificationSettings));
}

var loadGridLayout = function (serializedLayout) {
    for (var i = 0; i < serializedLayout.length; i++) {
        $("#" + serializedLayout[i]["id"]).attr("data-gs-width", serializedLayout[i]["width"]);
        $("#" + serializedLayout[i]["id"]).attr("data-gs-height", serializedLayout[i]["height"]);
        $("#" + serializedLayout[i]["id"]).attr("data-gs-x", serializedLayout[i]["x"]);
        $("#" + serializedLayout[i]["id"]).attr("data-gs-y", serializedLayout[i]["y"]);
    }
}

var resetGridLayout = function () {
    sendUpdatedGridLayout("");
    //Wait half a second for the grid to be updated before reloading the page
    setTimeout(function () {
        location.reload();
    }, 500);
}

var saveGridLayout = function () {
    var res = _.map($('.grid-stack .grid-stack-item:visible'), function (el) {
        el = $(el);
        var node = el.data('_gridstack_node');
        return {
            id: el.attr('id'),
            x: node.x,
            y: node.y,
            width: node.width,
            height: node.height
        };
    });
    return (JSON.stringify(res));
}

$(document).ready(function () {
    $('.grid-stack').on('change', function (event, items) {
        var newLayout = saveGridLayout();
        sendUpdatedGridLayout(newLayout);
    });
});