document.addEventListener('DOMContentLoaded', function () {
    const rows = document.querySelectorAll('.request-row');
    const detailsContainer = document.getElementById('requestDetails');
    let lastProductId = null;

    function loadProductDetails(id) {
        detailsContainer.innerHTML = '<p>Зареждане...</p>';

      //  fetch(`/RequestAdmin/_DetailsPartial/${id}`)
       fetch(`_DetailsPartial/${id}`)
            //.then(response => {
            //    if (!response.ok) throw new Error("Грешка при зареждане на данните");
            //    return response.text();
            //})
            .then(html => {
                detailsContainer.innerHTML = html;
            })
            .catch(error => {
                detailsContainer.innerHTML = `<p style="color:red;">${error.message}</p>`;
            });
    }

    rows.forEach(row => {
        row.addEventListener('mouseenter', () => {
            const id = row.getAttribute('data-id');

            if (id !== lastProductId) {
                lastProductId = id;
                loadProductDetails(id);
            }
        });
    });
});
