const previewImg = document.getElementById("photoPreview");
const removeCheckbox = document.getElementById("removePhotoCheckbox");
const photoInput = document.getElementById("Photo");

const originalPhoto = previewImg ? previewImg.src : null;
const avatarUrl = "/images/avatar.png";

// Максимален размер
const MAX_WIDTH = 512;
const MAX_HEIGHT = 512;

// 1) Автоматично намаляване + визуализация при качване
if (photoInput) {
    photoInput.addEventListener("change", function (event) {
        const file = event.target.files[0];
        if (!file) {
            previewImg.src = originalPhoto;
            return;
        }

        const reader = new FileReader();
        reader.onload = function (e) {
            const img = new Image();
            img.onload = function () {

                let width = img.width;
                let height = img.height;

                // Преоразмеряване
                if (width > MAX_WIDTH || height > MAX_HEIGHT) {
                    const ratio = Math.min(MAX_WIDTH / width, MAX_HEIGHT / height);
                    width = width * ratio;
                    height = height * ratio;
                }

                const canvas = document.createElement("canvas");
                canvas.width = width;
                canvas.height = height;

                const ctx = canvas.getContext("2d");
                ctx.drawImage(img, 0, 0, width, height);

                // Ново изображение (base64)
                const resizedDataUrl = canvas.toDataURL("image/jpeg", 0.85);
                previewImg.src = resizedDataUrl;

                // Създаваме Blob за upload
                canvas.toBlob(function (blob) {
                    const resizedFile = new File([blob], file.name, { type: "image/jpeg" });

                    // Заместваме оригиналния файл
                    const dataTransfer = new DataTransfer();
                    dataTransfer.items.add(resizedFile);
                    photoInput.files = dataTransfer.files;
                }, "image/jpeg", 0.85);

                // Махаме RemovePhoto ако качим нова снимка
                if (removeCheckbox) {
                    removeCheckbox.checked = false;
                }
            };

            img.src = e.target.result;
        };

        reader.readAsDataURL(file);
    });
}

// 2) RemovePhoto → avatar
if (removeCheckbox) {
    removeCheckbox.addEventListener("change", function () {
        if (this.checked) {
            previewImg.src = avatarUrl;
            if (photoInput) {
                photoInput.value = "";
            }
        } else {
            previewImg.src = originalPhoto;
        }
    });
}


