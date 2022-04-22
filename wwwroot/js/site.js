function deleteGadget(id) {
    let url = "/gadgets/delete?id="+ id;
    let formElement = document.getElementById("deleteForm");
    formElement.setAttribute("action", url);
    $("#deleteModal").modal('show');
}
