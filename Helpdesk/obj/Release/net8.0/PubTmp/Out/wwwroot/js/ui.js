//ui.js - общи функции за работа с UI
export function setHtml(selector, html) {    
    const el = document.querySelector(selector);
    if (el) el.innerHTML = html;
}

export function showLoader(selector) {
    /* document.querySelector(selector).innerHTML = "<p>Зареждане...</p>";*/
    setHtml(selector, "<p>Зареждане...</p>");
}

export function clearActiveRows() {
    document.querySelectorAll(".request-row").forEach(r => {
        r.classList.remove("active-row", "table-active");

        const statusCell = r.querySelector(".status-cell");

        if (statusCell) statusCell.textContent = "";
    });
}

export function markRowActive(row) {
    row.classList.add("active-row", "table-active");
    const statusCell = row.querySelector(".status-cell");
    if (statusCell) statusCell.textContent = "✏️";
}

export function clearHistory() {
    const container = document.querySelector("#historyContainer");
    if (container) container.innerHTML = "";
}

export function formatBgDate(dateString) {
    if (!dateString) return "";

    const d = new Date(dateString);

    const day = d.getDate();
    const month = d.getMonth() + 1;
    const year = d.getFullYear();

    const hours = d.getHours().toString().padStart(2, "0");
    const minutes = d.getMinutes().toString().padStart(2, "0");
    const seconds = d.getSeconds().toString().padStart(2, "0");

    return `${day}.${month}.${year} ${hours}:${minutes}:${seconds}`;
}


