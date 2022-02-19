class App {
    constructor() {
        this.form = document.querySelector('.js-form');
        this.header = this.form.querySelector('.js-form-header');
        this.message = this.form.querySelector('.js-form-message');
        this.emailRecipientWrapper = this.form.querySelector('.js-form-email-recipient-wrapper');
        this.emailRecipient = this.form.querySelector('.js-form-email-recipient');
        this.submit = this.form.querySelector('.js-form-btn');
        this.recipients = [];
        this.init();
    }


    init() {
        this.hendlerForm();
    }


    hendlerForm() {
        window.addEventListener('click', event => {
            const { target } = event;
            event.preventDefault();
            if (target.closest('.js-form-btn')) return this.sendWorker()
            if (target.closest('.js-btn-add-email')) return this.addEmail();
        });

        this.emailRecipient.addEventListener('change', event => {
            const { target } = event;
            const { value } = target;
            this.recipients.push(value);
            if (!this.isEmail(value)) return this.error("некорректный Email");
            const element = document.createElement('div');
            element.classList.add('email-recipients')
            element.innerHTML = value
            this.emailRecipient.value = ''
            this.recipients.forEach(email => this.emailRecipientWrapper.after(element));

            this.emailRecipientWrapper.classList.add('hidden');
        })
    }


    async service(data) {
        console.log(data);

        const respons = await fetch('/api/mails', {
            method: 'POST',
            headers: {
                'Content-Type':
                'application/json'
            },
            body: JSON.stringify(data)
        }).then(() => {

        }).catch((e) => {
            this.error(e)
        })
    }


    sendWorker() {
        const Subject = this.header.value;
        const Body = this.message.value;
        this.service({ Subject, Body, Recipients: this.recipients });
    }

    addEmail() {
        this.emailRecipientWrapper.classList.remove('hidden');
    }
    isEmail(email) {
        const pattern = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;
        return pattern.test(String(email).toLowerCase());
    }

    error(error) {
        const el = document.createElement('div');
        el.classList.add('error');
        el.innerHTML = error;
        this.form.appendChild(el);

        setTimeout(() => el.remove(), 5000)
    }
}

new App();