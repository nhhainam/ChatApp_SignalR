﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
"use strict";



var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();
document.getElementById("sendButton").disabled = true;


connection.on("ReceivedMess", function (user, message) {
    var li = document.createElement("li");
    document.getElementById("messageList").appendChild(li);
    li.textContent = user + " says: " + message;
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var chatid = document.getElementById("group").value;
    var myUserName = document.getElementById("myUserName").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", myUserName, message, chatid).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});


document.getElementById("setName").addEventListener("click", function (event) {
    var user = document.getElementById("myUserName").value;
    var charid = document.getElementById("group").value;
    connection.invoke("SetUserName", user,charid).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});