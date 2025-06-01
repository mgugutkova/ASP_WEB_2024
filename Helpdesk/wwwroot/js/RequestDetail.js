document.addEventListener('DOMContentLoaded', function () {
    const rows = document.querySelectorAll('.request-row');
    const detailsContainer = document.getElementById('detailsContainer');
    let lastHoveredId = null;
    let isEditing = false;
    console.log('RequestDetail.js loaded');

    function loadDetails(id) {
        if (isEditing || lastHoveredId === id) return;

        lastHoveredId = id;
        detailsContainer.innerHTML = '<p>Зареждане...</p>';

        fetch(`/Admin/RequestAdmin/DetailsPartial/${id}`)
            .then(response => {
                if (!response.ok) throw new Error("Грешка при зареждане на данните");
                return response.text();
            })
            .then(html => {
                detailsContainer.innerHTML = html;
            })
            .catch(error => {
                detailsContainer.innerHTML = `<p style="color:red;">${error.message}</p>`;
            });
    }

    function loadEditForm(id) {
        isEditing = true;
        detailsContainer.innerHTML = '<p>Зареждане на форма...</p>';

        fetch(`/Admin/RequestAdmin/EditPartial/${id}`)
            .then(response => {
                if (!response.ok) throw new Error("Неуспешно зареждане на формата");
                return response.text();
            })
            .then(html => {
                detailsContainer.innerHTML = html;
                attachFormSubmitHandler(); // handle form submit
            })
            .catch(error => {
                detailsContainer.innerHTML = `<p style="color:red;">${error.message}</p>`;
            });
    }

    function attachFormSubmitHandler() {
        const form = detailsContainer.querySelector('form');
        if (!form) return;

        form.addEventListener('submit', function (e) {
            e.preventDefault();

            const formData = new FormData(form);
            const id = formData.get("Id");

            fetch('/Admin/RequestAdmin/Edit', {
                method: 'POST',
                body: formData
            })
                .then(response => {
                    if (!response.ok) throw new Error("Грешка при запис");
                    return response.text();
                })
                .then(() => {
                    isEditing = false;
                    lastHoveredId = null;
                    loadDetails(id); // Презарежда детайли
                    clearActiveRowIndicators();
                })
                .catch(error => {
                    detailsContainer.innerHTML += `<p style="color:red;">${error.message}</p>`;
                });
        });
    }

    function clearActiveRowIndicators() {
        rows.forEach(r => {
            r.classList.remove('active-row');
            const statusCell = r.querySelector('.status-cell');
            if (statusCell) statusCell.textContent = '';
        });
    }

    // Събития по редове
    rows.forEach(row => {
        const id = row.getAttribute('data-id');

        row.addEventListener('mouseenter', () => {
            if (!isEditing) {
                loadDetails(id);
            }
        });

        row.addEventListener('click', () => {
            clearActiveRowIndicators();
            row.classList.add('active-row');

            const statusCell = row.querySelector('.status-cell');
            if (statusCell) statusCell.textContent = '✏️';

            loadEditForm(id);
        });
    });
});
