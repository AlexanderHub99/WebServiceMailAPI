class App {
    constructor() {
       // this.form = document.querySelector('.js-form');
       // this.header = form.querySelector('js-form-header');
       // this.message = form.querySelector('.js-form-message');
      //  this.submit = form.querySelector('.js-form-btn');
        this.init();
    }


    init() {
       this.hendlerForm();
    }


    hendlerForm() {
        window.addEventListener('click', event => {
            const { trget } = event.target;
            //if (target.classList.closest('.js-form-btn')) {
            //    const header = this.header.value;
            //    const message = this.message.value;
            //    const submit = this.submit.value;

                this.service();
                //if (header && message && submit) {
                   
                //}
         /*   }*/
        })
    }


    async service() {
        const response = await fetch('/api/mails', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                Subject: "test",
                Body: "test",
                Recipients: ["tima-Test@inbox.ru", "stESTa987654TEST878mail.com", "agTEST14tEST@gmail.com"],
            })
        });
    }
}

new App();