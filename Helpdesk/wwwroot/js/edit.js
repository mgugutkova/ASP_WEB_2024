/*import { getHtml, postForm } from "./api.js";*/
import { postForm } from "./api.js";
/*import { showLoader, setHtml, closeModal } from "./ui.js";*/
/*import { loadRequestsTable } from "./table.js";*/
import { loadDetails } from "./details.js";
import { updateRow } from "./table.js";
import { setTableScroll } from "./state.js";

export async function loadEditForm(id) {
    //showLoader("#detailsContainer");
    //const html = await getHtml(`/Admin/RequestAdmin/EditPartial/${id}`);
    //setHtml("#detailsContainer", html);
    const r = await fetch(`/Admin/RequestAdmin/EditPartial/${id}`);
    const html = await r.text();
    document.querySelector("#detailsContainer").innerHTML = html;
    attachEditHandler();
}

function attachEditHandler() {
    const form = document.querySelector("#detailsContainer form");
    if (!form) return;

    form.addEventListener("submit", async (e) => {
        e.preventDefault();

        const formData = new FormData(form);
        const id = formData.get("Id");

        // 👇 запомняме scroll позицията
        const scroller =
            document.querySelector(".request-table-container");

        if (scroller) {
            setTableScroll(scroller.scrollTop);
        }


        const result = await postForm("/Admin/RequestAdmin/Edit", formData);

        if (result.success) {
            updateRow(result.row);   
          /*  await loadRequestsTable();*/
            await loadDetails(id);
        } else {
            form.insertAdjacentHTML("beforeend",
                `<p class="text-danger">Грешка при запис.</p>`
            );
        }
    });
}