let emailRegExp = /^[^\s]+@[a-zA-Z]{2,5}\.[a-zA-Z]{2,3}$/;

let telRegExp = /^\(\d{3}\)\s+\d{3}-\d{2}-\d{2}$/;

let nameRegExp = /^[a-zA-Zа-яА-ЯёЁ]{1,20}$/;

let button = document.getElementById('submition');


document.getElementById('form').addEventListener('submit', function(e){
    e.preventDefault();
    clearErrors();
    

    let surname = document.getElementById('surname');
    if(!nameRegExp.test(surname.value)){
        let surnameError = document.getElementById('surnameError');
        surnameError.textContent = 'Фамилия введена неправильно';
    }

    let name = document.getElementById('name');
    if(!nameRegExp.test(name.value)){
        let nameError = document.getElementById('nameError');
        nameError.textContent = 'Имя введено неправильно';
    }


    let email = document.getElementById('email');
    if(!emailRegExp.test(email.value)){
        let emailError = document.getElementById('emailError');
        emailError.textContent = 'E-mail введен неправильно';
    }
    
    let tel = document.getElementById('tel');
    if(!telRegExp.test(tel.value)){
        let telError = document.getElementById('telError');
        telError.textContent = 'Телефон введен неправильно';

    }

    let city = document.getElementById('city');
    let check = document.getElementById('bstuStudy');
    let course3 = document.getElementById('course3');
    if(check.checked == false || course3.checked == false || city.value != "Минск")
        confirm('Вы уверены в правильности данных?');


    let about = document.getElementById('about');
    if(about.value.length == 0 || about.value.length > 250 ){
        let aboutError = document.getElementById('aboutError');
        aboutError.textContent = 'Поле заполнено неправильно';
    }



})


function clearErrors(){
    let surnameError = document.getElementById('surnameError');
    let nameError = document.getElementById('nameError');
    let emailError = document.getElementById('emailError');
    let telError = document.getElementById('telError');
    let aboutError = document.getElementById('aboutError');

    surnameError.textContent = '';
    nameError.textContent = '';
    emailError.textContent = '';
    telError.textContent = '';
    aboutError.textContent = '';

}