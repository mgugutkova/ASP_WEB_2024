//state.js - съхранява глобално състояние за избраната заявка и scroll позицията на таблицата

export let selectedRequestId = null;
export let tableScrollTop = 0;

export function setSelectedRequest(id) {
    selectedRequestId = id;
}

export function getSelectedRequest() {
    return selectedRequestId;
}

export function setTableScroll(top) {
    tableScrollTop = top;
}

export function getTableScroll() {
    return tableScrollTop;
}