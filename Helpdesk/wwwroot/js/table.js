import { formatBgDate } from "./ui.js";

export function updateRow(rowData) {
    const row = document.querySelector(
        `.request-row[data-id="${rowData.id}"]`
    );
    if (!row) return;

    const cells = row.children;

    // ⚠️ индексите да отговарят на колоните ти
    cells[1].textContent = rowData.requestNumber;
   //cells[2].textContent = rowData.startDate;
  // cells[2].textContent = rowData.startDate.ToString("d.M.yyyy HH:mm:ss");
   cells[2].textContent = formatBgDate(rowData.startDate);
    cells[3].textContent = rowData.userFullName;
    cells[4].textContent = rowData.categoryName;
    cells[5].textContent = rowData.requestState;
    cells[6].textContent = rowData.directorateName;
}




//import { getHtml } from "./api.js";
//import { setHtml } from "./ui.js";
//import { getSelectedRequest, getTableScroll } from "./state.js";
//import { markRowActive } from "./ui.js";

//export async function loadRequestsTable() {
//    const html = await getHtml("/Admin/RequestAdmin/RequestsTable");
//    setHtml("#requestsTableContainer", html);

//    // 🔁 възстановяване на маркирания ред
//    const selectedId = getSelectedRequest();
//    if (!selectedId) return;

//    const row = document.querySelector(
//        `.request-row[data-id="${selectedId}"]`
//    );

//    if (row) {
//        markRowActive(row);

//        //// 🧭 UX бонус – скрол до реда
//        //row.scrollIntoView({
//        //    behavior: "smooth",
//        //    block: "center"
//        //});
//    }


//// 🔁 възстановяване на scroll позицията
//const tableContainer =
//    document.querySelector(".request-table-container");

//if (tableContainer) {
//    tableContainer.scrollTop = getTableScroll();
//}
//}