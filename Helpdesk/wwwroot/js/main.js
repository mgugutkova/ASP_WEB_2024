//main.js - основен файл за зареждане на всички функции и събития в приложението
//console.log(
//    "scrollTop:", container.scrollTop,
//    "clientHeight:", container.clientHeight,
//    "scrollHeight:", container.scrollHeight
//);




import { clearActiveRows, markRowActive, clearHistory } from "./ui.js";
import { loadEditForm } from "./edit.js";
import { loadHistory } from "./details.js";
import { setSelectedRequest } from "./state.js";

let skip = 0;
const take = 10;
let isLoading = false;
let noMoreData = false;

let stateId = window.stateId ?? 0;

const url = `/Admin/RequestAdmin/RequestsPage?stateId=${stateId}&skip=${skip}&take=${take}`;
console.log("FETCH URL:", url)


export async function loadMore() {
    if (isLoading || noMoreData) return;

    isLoading = true;

    const response = await fetch(`/Admin/RequestAdmin/RequestsPage?stateId=${stateId}&skip=${skip}&take=${take}`);
  
    const html = await response.text();

    if (html.trim().length === 0) {
        noMoreData = true;
        isLoading = false;
        return;
    }

    document.querySelector("#requestTableBody")
        .insertAdjacentHTML("beforeend", html);

    skip += take;
    isLoading = false;
}

function initInfiniteScroll() {
    const container = document.querySelector("#requestsTableContainer");

    container.addEventListener("scroll", () => {
        const scrollBottom = container.scrollTop + container.clientHeight;
        const scrollHeight = container.scrollHeight;

        if (scrollBottom >= scrollHeight - 100) {
            loadMore();
        }
    });

    loadMore();
}

document.addEventListener("DOMContentLoaded", () => {
    initInfiniteScroll();

    document.addEventListener("click", (e) => {
        const historyBtn = e.target.closest(".load-history-btn");
        if (historyBtn) {
            loadHistory(historyBtn.dataset.requestId);
            return;
        }

        const row = e.target.closest(".request-row");
        if (row && !e.target.closest("#detailsContainer")) {
            const id = row.dataset.id;
            setSelectedRequest(id);

            clearHistory();
            clearActiveRows();
            markRowActive(row);
            loadEditForm(id);
        }
    });
});



//import { clearActiveRows, markRowActive, clearHistory } from "./ui.js";
//import { loadEditForm } from "./edit.js";
//import { loadHistory } from "./details.js";
//import { setSelectedRequest, getTableScroll } from "./state.js";

//// ------------------------------
//// LAZY LOADING НА ТАБЛИЦАТА
//// ------------------------------

//let skip = 0;
//const take = 10;
//let isLoading = false;
//let noMoreData = false;

//export async function loadMore() {
//    if (isLoading || noMoreData) return;

//    isLoading = true;

//   const response = await fetch(`/Admin/RequestAdmin/RequestsPage?skip=${skip}&take=${take}`);
//    const html = await response.text();

//    if (html.trim().length === 0) {
//        noMoreData = true;
//        isLoading = false;
//        return;
//    }
//    document.querySelector("#requestTableBody")
//        .insertAdjacentHTML("beforeend", html);

//    skip += take;
//    isLoading = false;

//    //// Връщаме скрола, ако е бил запазен
//    //const savedScroll = getTableScroll();
//    //if (savedScroll > 0) {
//    //    container.scrollTop = savedScroll;
//    //} else {
//    //    container.scrollTop = oldScroll;
//    //}
//}

//function initInfiniteScroll() {
//    //window.addEventListener("scroll", () => {
//    //    const scrollPosition = window.innerHeight + window.scrollY;
//    //    const bottom = document.body.offsetHeight - 300;

//    //    if (scrollPosition >= bottom) {
//    //        loadMore();
//    //    }
//    //});

//    const container = document.querySelector("#requestsTableContainer");

//    container.addEventListener("scroll", () => {
//        const scrollBottom = container.scrollTop + container.clientHeight;
//        const scrollHeight = container.scrollHeight;

//        if (scrollBottom >= scrollHeight - 100) {
//            loadMore();
//        }
//    });

//    // Зареждаме първите 10 реда
//    loadMore();
//}


//document.addEventListener("DOMContentLoaded", () => {

//    initInfiniteScroll();  
//    document.addEventListener("click", (e) => {

//        // История
//        const historyBtn = e.target.closest(".load-history-btn");
//        if (historyBtn) {
//            loadHistory(historyBtn.dataset.requestId);
//            return;
//        }

//        // Ред от таблицата
//        const row = e.target.closest(".request-row");
//        if (row && !e.target.closest("#detailsContainer")) {

//            const id = row.dataset.id;
//            setSelectedRequest(id);   // 👈 КЛЮЧОВ РЕД

//            clearHistory();
//            clearActiveRows();
//            markRowActive(row);
//            loadEditForm(row.dataset.id);
//        }
//    });

//});