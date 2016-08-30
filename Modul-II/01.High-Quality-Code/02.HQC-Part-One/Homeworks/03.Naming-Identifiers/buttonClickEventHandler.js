function buttonClickEventHandler(event, arguments) {
    var currentWindow = window,
        browserName = currentWindow.navigator.appCodeName,
        isMozzilla = false;

    isMozzilla = browserName === "Mozzila";
    if (isMozzilla) {
        alert("Yes");
    } else {
        alert("No");
    }
}
