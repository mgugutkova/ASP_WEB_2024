//table.js - отговаря за обновяване на редовете в таблицата след редакция

import { formatBgDate } from "./ui.js";

export function updateRow(rowData) {
    const row = document.querySelector(
        `.request-row[data-id="${rowData.id}"]`
    );
    if (!row) return;

    const cells = row.children;

    // ⚠️ индексите да отговарят на колоните ти
    cells[1].textContent = rowData.requestNumber;
    cells[2].textContent = formatBgDate(rowData.startDate);
    cells[3].textContent = rowData.userFullName;
    cells[4].textContent = rowData.categoryName;
    cells[5].textContent = rowData.requestState;
    cells[6].textContent = rowData.directorateName;
}

