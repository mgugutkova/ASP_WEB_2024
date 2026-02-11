import { getHtml, postForm } from "./api.js";
import { showLoader, setHtml, closeModal } from "./ui.js";
import { loadRequestsTable } from "./table.js";
import { loadDetails } from "./details.js";

export async function loadEditForm(id) {
    showLoader("#detailsContainer");
    const html = await getHtml(`/Admin/RequestAdmin/EditPartial/${id}`);
    setHtml("#detailsContainer", html);
    attachEditHandler();
}

function attachEditHandler() {
    const form = document.querySelector("#detailsContainer form");
    if (!form) return;

    form.addEventListener("submit", async (e) => {
        e.preventDefault();

        const formData = new FormData(form);
        const id = formData.get("Id");

        const result = await postForm("/Admin/RequestAdmin/Edit", formData);

        if (result.success) {
            await loadRequestsTable();
            await loadDetails(id);
        } else {
            form.insertAdjacentHTML("beforeend",
                `<p class="text-danger">Грешка при запис.</p>`
            );
        }
    });
}