// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
//window.addEventListener("load", solve);
function solve() {
    const priceElement = parseFloat(document.getElementById('price').value)
    const durationElement = parseFloat(document.getElementById('duration').value)
    const ainterestElement = document.getElementById('ainterest')
    const returnPriceElement = document.getElementById('returnprice')
    const calculateElement = document.getElementById('calculate')

    calculateElement.addEventListener('click', () => {

        ainterestElement.value = (durationElement * 0.3)
        returnPriceElement.value = (priceElement + (durationElement * 0.3))
        
    })
}
