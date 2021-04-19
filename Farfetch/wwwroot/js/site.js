const uri = 'api/Itens';
let itens = [];

function getItens() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayItens(data))
        .catch(error => console.error('Unable to get items.', error));
}

function addItem() {

    const txtName = document.getElementById('add-name');
    const txtMaterial = document.getElementById('add-material');
    const txtBrandName = document.getElementById('add-brandname');
    const txtDesigner = document.getElementById('add-designer');
    const txtColor = document.getElementById('add-color');
    const txtSeason = document.getElementById('add-season');

    const item = {
        name: txtName.value.trim(),
        material: txtMaterial.value.trim(),
        brandname: txtBrandName.value.trim(),
        designer: txtDesigner.value.trim(),
        color: txtColor.value.trim(),
        season: txtSeason.value.trim()
    };

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(item)
    })
        .then(response => response.json())
        .then(() => {
            getItens();
            txtName.value = '';
            txtMaterial.value = '';
            txtBrandName.value = '';
            txtDesigner.value = '';
            txtColor.value = '';
            txtSeason.value = '';
            document.getElementById('btnAdd').style.display = 'block';
            document.getElementById('addForm').style.display = 'none';
        })
        .catch(error => console.error('Unable to add item.', error));
}

function deleteItem(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getItens())
        .catch(error => console.error('Unable to delete item.', error));
}

function details(id) {
    const item = itens.find(item => item.id === id);

    document.getElementById('detail-name').innerHTML = "" + item.name;
    document.getElementById('detail-material').innerHTML = "" + item.material;
    document.getElementById('detail-brandname').innerHTML = "" + item.brandName;
    document.getElementById('detail-designer').innerHTML = "" + item.designer;
    document.getElementById('detail-color').innerHTML = "" + item.color;
    document.getElementById('detail-season').innerHTML = "" + item.season;

    document.getElementById('details').style.display = 'block';
    document.getElementById('tableItens').style.display = 'none';
}

function displayEditForm(id) {
    const item = itens.find(item => item.id === id);

    document.getElementById('edit-name').value = item.name;
    document.getElementById('edit-id').value = item.id;
    document.getElementById('edit-material').value = item.material;
    document.getElementById('edit-brandname').value = item.brandName;
    document.getElementById('edit-designer').value = item.designer;
    document.getElementById('edit-color').value = item.color;
    document.getElementById('edit-season').value = item.season;

    document.getElementById('editForm').style.display = 'block';
    document.getElementById('btnAdd').style.display = 'none';
    document.getElementById('tableItens').style.display = 'none';
    document.getElementById('details').style.display = 'none';
}

function displayAddForm() {
    document.getElementById('addForm').style.display = 'block';
    document.getElementById('btnAdd').style.display = 'none';
}


function updateItem() {
    const itemId = document.getElementById('edit-id').value;
    const txtName = document.getElementById('edit-name');
    const txtMaterial = document.getElementById('edit-material');
    const txtBrandName = document.getElementById('edit-brandname');
    const txtDesigner = document.getElementById('edit-designer');
    const txtColor = document.getElementById('edit-color');
    const txtSeason = document.getElementById('edit-season');

    const item = {
        id: parseInt(itemId, 10),
        name: txtName.value.trim(),
        material: txtMaterial.value.trim(),
        brandname: txtBrandName.value.trim(),
        designer: txtDesigner.value.trim(),
        color: txtColor.value.trim(),
        season: txtSeason.value.trim()
    };

    fetch(`${uri}/${itemId}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(item)
    })
        .then(() => getItens())
        .catch(error => console.error('Unable to update item.', error));

    closeInput();
    return false;
}

function closeInput() {
    document.getElementById('editForm').style.display = 'none';
    document.getElementById('addForm').style.display = 'none';
    document.getElementById('btnAdd').style.display = 'block';
    document.getElementById('details').style.display = 'none';
    document.getElementById('tableItens').style.display = 'block';
}

function _displayCount(itemCount) {
    const name = (itemCount === 1) ? 'Item' : 'Itens';

    document.getElementById('counter').innerText = `${itemCount} ${name}`;
}

function _displayItens(data) {
    const tBody = document.getElementById('itens');
    tBody.innerHTML = '';

    _displayCount(data.length);

    const button = document.createElement('button');

    data.forEach(item => {

        //let editButton = button.cloneNode(false);
        //editButton.innerText = 'Edit';
        //editButton.setAttribute('onclick', `displayEditForm(${item.id})`);
        //editButton.setAttribute('class', "btn btn-primary");

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', `deleteItem(${item.id})`);
        deleteButton.setAttribute('class', "btn btn-danger");

        let tr = tBody.insertRow();
        tr.setAttribute('onclick', `details(${item.id})`);

        let td2 = tr.insertCell(0);
        let textNode = document.createTextNode(item.name);
        td2.appendChild(textNode);

        let td4 = tr.insertCell(1);
        let textNode2 = document.createTextNode(item.brandName);
        td4.appendChild(textNode2);

        let td5 = tr.insertCell(2);
        td5.appendChild(deleteButton);
  
    });

    itens = data;
}