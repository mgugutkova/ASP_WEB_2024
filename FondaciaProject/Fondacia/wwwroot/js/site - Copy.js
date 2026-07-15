// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


    const removeCheckbox = document.getElementById("removePhotoCheckbox");
    const previewImg = document.getElementById("photoPreview");

    const originalPhoto = previewImg.src; // запомняме оригиналната снимка
    const avatarUrl = "/images/avatar.png"; // път към avatar.png

    removeCheckbox.addEventListener("change", function () {
        if (this.checked) {
        previewImg.src = avatarUrl; // показваме avatar
        } else {
        previewImg.src = originalPhoto; // връщаме оригиналната снимка
        }
    });

