function createMessageEntry(encodedName, encodedMsg) {
                
    var entry = document.createElement('div');
    entry.classList.add("message-entry");
    if (encodedName === "_SYSTEM_") {
        entry.innerHTML = encodedMsg;
        entry.classList.add("text-center");
        entry.classList.add("system-message");
    } else if (encodedName === "_BROADCAST_") {
        entry.classList.add("text-center");
        entry.innerHTML = `<div class="text-center broadcast-message">${encodedMsg}</div>`;
    } else if (encodedName === username) {
        entry.innerHTML = `<div class="message-avatar pull-right">${encodedName}</div>` +
            `<div class="message-content pull-right">${encodedMsg}<div>`;
    } else {
        entry.innerHTML = `<div class="message-avatar pull-left">${encodedName}</div>` +
            `<div class="message-content pull-left">${encodedMsg}<div>`;
    }
    return entry;
}




function ToPage(name)
{
console.log('hi')


    var encodedMsg = JSON.stringify( name);
    var messageEntry = createMessageEntry('device', encodedMsg);
                
    var messageBox = document.getElementById('messages');
    messageBox.appendChild(messageEntry);
    messageBox.scrollTop = messageBox.scrollHeight;
    var payload = name.myEventHubMessage
    var deviceMessage = JSON.parse(payload)
    var myElement = $("#temp").html(deviceMessage.temperature);

}