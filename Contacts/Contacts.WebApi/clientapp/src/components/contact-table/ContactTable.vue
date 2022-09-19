<template>
  <div>
    <div class="mb-3">
      <h1>Contact Table</h1>
      <b-button
        size="md"
        squared variant="primary"
        @click="createContact()">
        Create Contact <b-icon icon="person-plus-fill" aria-hidden="true"></b-icon>
      </b-button>
    </div>
    <b-table small :items="contacts" :fields="fields" responsive="sm">
      <template #cell(name)="data">
        {{ data.item.name }}
      </template>
      <template #cell(mobilePhone)="data">
        {{ data.item.mobilePhone }}
      </template>
      <template #cell(birthDate)="data">
        {{ data.item.birthDate | dateFormat }}
      </template>
      <template #cell(actions)="data">
        <b-button
          size="sm"
          squared variant="warning"
          @click="updateContact(data.item.id)">
          Update <b-icon icon="person-check-fill" aria-hidden="true"></b-icon>
        </b-button>
        <b-button
            size="sm"
            class="mr-1"
            squared variant="danger"
            @click="deleteContact(data.item.id)">
          Delete <b-icon icon="person-dash-fill" aria-hidden="true"></b-icon>
        </b-button>
      </template>
    </b-table>
    <ContactAddEditModal :contact-id=selectedContactId ref="contactAddEditModal"/>
  </div>
</template>

<script>
import ContactAddEditModal from "../contact-add-edit/ContactAddEditModal";
import {nextTick} from "vue";

export default {
  components: {
    ContactAddEditModal,
  },
  created() {
    this.$api.get("api/contacts").then(result => {
      this.contacts = result.data;
    })
  },
  data() {
    return {
      contacts: [
          {id : 1, name: "Dima", mobilePhone: "+375291990245", jobTitle: "Addidas", birthDate: new Date() },
          {id : 2, name: "Roma", mobilePhone: "+375291990245", jobTitle: "Itransition", birthDate: new Date()},
          {id : 3, name: "Random", mobilePhone: "+375291990245", jobTitle: "Nike", birthDate: new Date()},
      ],
      fields: [
        { key: 'name', label: 'Contact Name', },
        { key: 'mobilePhone', label: 'Mobile Phone' },
        { key: 'jobTitle', label: 'Job Title' },
        { key: 'birthDate', label: 'Birth Date' },
        { key: 'actions', label: 'Actions'}
      ],
      selectedContactId: 0
    };
  },
  methods: {
    updateContact(id) {
      this.openAddEditModel(id);
    },

    deleteContact(id) {
      console.log(id);
    },

    createContact() {
      this.openAddEditModel(0);
    },

    openAddEditModel(id) {
      this.selectedContactId = id;

      nextTick( () => {
        this.$refs.contactAddEditModal.show();
      });
    }

  },
}
</script>

<style scoped>

</style>