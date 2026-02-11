import { clearActiveRows, markRowActive } from "./ui.js";
import { loadEditForm } from "./edit.js";
import { loadHistory } from "./details.js";

document.addEventListener("DOMContentLoaded", () => {

    document.addEventListener("click", (e) => {

        // История
        const historyBtn = e.target.closest(".load-history-btn");
        if (historyBtn) {
            loadHistory(historyBtn.dataset.requestId);
            return;
        }

        // Ред от таблицата
        const row = e.target.closest(".request-row");
        if (row && !e.target.closest("#detailsContainer")) {
            clearActiveRows();
            markRowActive(row);
            loadEditForm(row.dataset.id);
        }
    });

});