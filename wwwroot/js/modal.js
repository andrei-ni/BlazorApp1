window.showModal = () => {
    var myModal = new bootstrap.Modal(document.getElementById('testModal'));
    if (myModal != null) {
        myModal.show();
    }
}

//const myModal = document.getElementById('myModal')
//const myInput = document.getElementById('myInput')

//myModal.addEventListener('shown.bs.modal', () => {
//    myInput.focus()
//})