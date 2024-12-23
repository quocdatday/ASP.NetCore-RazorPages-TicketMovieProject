function Delete(value) {
    var DValue = document.getElementById("DeleteValue").value = value;
    var frame = document.getElementById("Delete");
    frame.style.transition = "1s";
    if (frame.className == "fixed-top top-100 container") {
        frame.className = frame.className.replace("fixed-top top-100 container", "fixed-top top-50 translate-middle-y container");
        return 0;
    }
    if (frame.className == "fixed-top top-50 translate-middle-y container") {
        frame.className = frame.className.replace("fixed-top top-50 translate-middle-y container", "fixed-top top-100 container");
        return 0;
    }
}