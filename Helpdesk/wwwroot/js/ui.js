export function setHtml(selector, html) {
    document.querySelector(selector).innerHTML = html;
}

export function showLoader(selector) {
    document.querySelector(selector).innerHTML = "<p>Зареждане...</p>";
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

// Bootstrap 5 modal (native)
export function openModal() {
    const modalEl = document.getElementById("modal");
    const modal = new bootstrap.Modal(modalEl);
    modal.show();
}

export function closeModal() {
    const modalEl = document.getElementById("modal");
    const modal = bootstrap.Modal.getInstance(modalEl);
    modal.hide();
}

export function clearHistory() {
    const container = document.querySelector("#historyContainer");
    if (container) container.innerHTML = "";
}
