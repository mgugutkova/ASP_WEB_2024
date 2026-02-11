import { getHtml } from "./api.js";
import { setHtml } from "./ui.js";

export async function loadRequestsTable() {
    const html = await getHtml("/Admin/RequestAdmin/RequestsTable");
    setHtml("#requestsTableContainer", html);
}