<template>
  <div>
    <b-modal
      ref="contactModal"
      id="modal-center"
      centered
      :title=modalTitleComputed>
      <b-form  @submit="onSubmit">
        <label>Name: </label>
        <b-form-input v-model="form.name" :state="nameValidation" id="contact-name"></b-form-input>
        <b-form-invalid-feedback :state="nameValidation">
          Contact name must be 3-30 characters long.
        </b-form-invalid-feedback>
        <label>Job Title: </label>
        <b-form-input v-model="form.jobTitle" :state="jobTitleValidation" id="contact-jobTitle"></b-form-input>
        <b-form-invalid-feedback :state="jobTitleValidation">
          Contact job title must be at least 3 characters long.
        </b-form-invalid-feedback>
        <label>Mobile Phone: </label>
        <b-form-input v-model="form.mobilePhone" :state="mobilePhoneValidation" id="contact-mobilePhone"></b-form-input>
        <b-form-invalid-feedback :state="mobilePhoneValidation">
          Contact mobile phone must be the accord this mask: +__-__-_______ .
        </b-form-invalid-feedback>
        <label>Choose a birth date: </label>
        <b-form-datepicker v-model="form.birthDate" :state="birthDateValidation" id="contact-birthdate" class="mb-2">
        </b-form-datepicker>
        <b-form-invalid-feedback :state="birthDateValidation">
          Birth date is required field.
        </b-form-invalid-feedback>
        <b-button type="submit" variant="primary">Submit</b-button>
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
      } else {
        this.modalTitle = 'Create Contact';
      }

      this.$refs.contactModal.show();
    },
    onSubmit(event) {
      event.preventDefault();
      console.log("Submit");
      if (!this.contactId) {
        this.$api.post("api/contacts", this.form).then(() => {
          console.log("created");
        });
      }
      else {
        this.form.id = this.contactId;
        this.$api.put("contacts", this.form).then(() => {
          console.log("updated");
        });
      }

    },
  },
  computed: {
    modalTitleComputed() {
      return this.modalTitle;
    },
    nameValidation() {
      return this.form.name.length >= 3
          && this.form.name.length <= 30
    },
    jobTitleValidation() {
      return this.form.jobTitle.length !== 0;
    },
    birthDateValidation() {
      return this.form.birthDate !== null;
    },
    mobilePhoneValidation() {
      return this.form.mobilePhone.length === 8;
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