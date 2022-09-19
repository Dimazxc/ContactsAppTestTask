<template>
  <div>
    <b-modal
      ref="contactModal"
      id="contact-modal"
      centered
      @ok="onSubmit"
      :title=modalTitleComputed>
      <b-form>
        <label>Name: </label>
        <b-form-input v-model="form.name" :state="nameValidation" id="contact-name"></b-form-input>
        <b-form-invalid-feedback :state="nameValidation">
          Contact name must be 3-20 characters long.
        </b-form-invalid-feedback>
        <label>Job Title: </label>
        <b-form-input v-model="form.jobTitle" :state="jobTitleValidation" id="contact-jobTitle"></b-form-input>
        <b-form-invalid-feedback :state="jobTitleValidation">
          Contact job title must be least 3-30 characters long.
        </b-form-invalid-feedback>
        <label>Mobile Phone: </label>
        <b-form-input type="number" v-model="form.mobilePhone" :state="mobilePhoneValidation" id="contact-mobilePhone"></b-form-input>
        <b-form-invalid-feedback :state="mobilePhoneValidation">
          Contact mobile phone must be 12 characters long.
        </b-form-invalid-feedback>
        <label>Choose a birth date: </label>
        <b-form-datepicker v-model="form.birthDate" :state="birthDateValidation" id="contact-birthdate" class="mb-2">
        </b-form-datepicker>
        <b-form-invalid-feedback :state="birthDateValidation">
          Birth date is required field.
        </b-form-invalid-feedback>
      </b-form>
    </b-modal>
  </div>
</template>

<script>
export default {
  props: {
    contactId: {
      type: Number,
      required: false
    }
  },
  data() {
    return {
      form: {
        id: 0,
        name: '',
        jobTitle: '',
        mobilePhone: '',
        birthDate: null
      },
      modalTitle: ''
    };
  },
  methods: {
    show() {
      if (this.contactId) {
        this.modalTitle = 'Update Contact';

        this.setFormValues();
      } else {
        this.modalTitle = 'Create Contact';
      }

      this.$refs.contactModal.show();
    },
    onSubmit(bvModalEvent) {
      bvModalEvent.preventDefault();

      let contact = {
        id: this.contactId,
        name: this.form.name,
        mobilePhone: this.form.mobilePhone,
        jobTitle: this.form.jobTitle,
        birthDate: this.form.birthDate
      }
      if (this.contactId) {
        this.form.id = this.contactId;
        this.$api.put("api/contacts", contact).then(() => {
          this.$emit('on-contact-updated', contact);
        });
      }
      else {
        this.$api.post("api/contacts", contact).then((result) => {
          contact.id = result.data;
          this.$emit('on-contact-added', contact);
        });
      }

      this.$nextTick(() => {
        this.clearForm();
        this.$bvModal.hide('contact-modal');
      })
    },
    setFormValues() {
      this.$api.get(`api/contacts/${this.contactId}`).then(result => {
        let contact = result.data;

        this.form.name = contact.name;
        this.form.mobilePhone = contact.mobilePhone;
        this.form.jobTitle = contact.jobTitle;
        this.form.birthDate = contact.birthDate;
      })
    },
    clearForm() {
      this.form.id = 0;
      this.form.name = '';
      this.form.jobTitle = '';
      this.form.mobilePhone = '';
      this.form.birthDate = null;
    }
  },
  computed: {
    modalTitleComputed() {
      return this.modalTitle;
    },
    nameValidation() {
      return this.form.name.length >= 3
          && this.form.name.length <= 20
    },
    jobTitleValidation() {
      return this.form.jobTitle.length >= 3
          && this.form.jobTitle.length <= 30
    },
    birthDateValidation() {
      return this.form.birthDate !== null;
    },
    mobilePhoneValidation() {
      return this.form.mobilePhone.length === 12;
    },
    isFormValid() {
      return this.nameValidation
        && this.jobTitleValidation
        && this.mobilePhoneValidation
        && this.birthDateValidation;
    }
  }
}
</script>