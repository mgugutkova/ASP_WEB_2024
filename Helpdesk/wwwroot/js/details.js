import { getHtml } from "./api.js";
import { showLoader, setHtml } from "./ui.js";

export async function loadDetails(id) {
    showLoader("#detailsContainer");
    const html = await getHtml(`/Admin/RequestAdmin/DetailsPartial/${id}`);
    setHtml("#detailsContainer", html);
}

export async function loadHistory(id) {
    showLoader("#historyContainer");
    const html = await getHtml(`/Admin/RequestAdmin/HistoryPartial?id=${id}`);
    setHtml("#historyContainer", html);
}