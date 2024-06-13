
function focusElement(id) {

    setTimeout(() => {
        const element = document.getElementById(id);
        element.focus()
    }, 200);
}