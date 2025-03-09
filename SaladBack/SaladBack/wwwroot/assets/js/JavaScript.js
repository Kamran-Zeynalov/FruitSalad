const searchForm = document.querySelector('.search');
const searchInput = searchForm.querySelector('.search-input');

searchForm.addEventListener('submit', (e) => {
    e.preventDefault();
    const searchQuery = searchInput.value.trim();
    if (searchQuery == "") {
        alert("Nese Yaz...");
        return;
    }
    fetch(`/AdminOfSalads/Fruit/Search?name=${(searchQuery)}`)
        .then(response => response.text())
        .then(data => {
            const partialContainer = document.getElementById('partials');
            partialContainer.innerHTML = data;
        })
        .catch(error => console.error('Fetch hatası:', error));
});