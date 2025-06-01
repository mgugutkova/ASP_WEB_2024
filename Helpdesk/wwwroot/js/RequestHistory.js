document.addEventListener('DOMContentLoaded', () => {
    const historyContainer = document.getElementById('historyContainer');

    // 1. Изчистване на историята при клик на ред
    document.querySelectorAll('.request-row').forEach(row => {
        row.addEventListener('click', () => {
            if (historyContainer) {
                historyContainer.innerHTML = ''; // Зачиства съдържанието
            }

            // (по избор) маркирай избрания ред
            document.querySelectorAll('.request-row').forEach(r => r.classList.remove('table-active'));
            row.classList.add('table-active');
        });
    });

    // 2. Зареждане на история при клик на бутон
    document.querySelectorAll('.load-history-btn').forEach(btn => {
        btn.addEventListener('click', async () => {
            const id = btn.dataset.requestId;

            if (!id || !historyContainer) return;

            try {
                const response = await fetch(`/Admin/RequestAdmin/HistoryPartial?id=${id}`);
                if (!response.ok) throw new Error('Неуспешно зареждане');

                const html = await response.text();
                historyContainer.innerHTML = html;
            } catch (err) {
                console.error('Грешка при зареждане:', err);
            }
        });
    });
});



//document.addEventListener('DOMContentLoaded', () => {
//    document.querySelectorAll('.load-history-btn').forEach(btn => {
//        btn.addEventListener('click', async () => {
//            const id = btn.dataset.requestId;
//            const container = document.getElementById('historyContainer');

//            if (!id || !container) return;

//            try {
//                const response = await fetch(`/Admin/RequestAdmin/HistoryPartial?id=${id}`);
//                if (!response.ok) throw new Error('Неуспешно зареждане');

//                const html = await response.text();
//                container.innerHTML = html;
//            } catch (err) {
//                console.error('Грешка при зареждане:', err);
//            }
//        });
//    });
//});


//document.addEventListener('DOMContentLoaded', () => {
//    const btn = document.getElementById('loadHistoryBtn');
//    const container = document.getElementById('historyContainer');   
//    console.log('RequestHistory.js loaded');
//    console.log('BTN:', btn);
//    console.log('Container:', container);

//    if (!btn || !container) return;

//    btn.addEventListener('click', async () => {
//        const id = btn.dataset.requestId; 
//       // console.log('ID:', id);
//       // const url = `/Admin/RequestAdmin?handler=HistoryPartial&id=${id}`;
//      //  const url = `/Admin/RequestAdmin/HistoryPartial?id=${id}`;
//        const url = `/Admin/RequestAdmin/HistoryPartial/${id}`;
     
//      //  console.log('URL:', url);
//        try {
//            const response = await fetch(url);
//            console.log("HTTP Status:", response.status);
//            if (!response.ok) throw new Error('Неуспешно зареждане');

//            const html = await response.text();
//            container.innerHTML = html;
//        } catch (err) {
//            console.error('Грешка при зареждане:', err);
//        }
//    });
//});
