<script setup lang="ts">
import { ref } from "vue";
import { useQuery, useMutation } from "@vue/apollo-composable";
import gql from "graphql-tag";

/* ---------- Query ---------- */

const GET_BOOKS = gql`
  query {
    books {
      id
      title
      author
    }
  }
`;

/* ---------- Mutation ---------- */

const CREATE_BOOK = gql`
  mutation ($title: String!, $author: String!) {
    createBook(title: $title, author: $author) {
      id
      title
      author
    }
  }
`;

/* ---------- State ---------- */

const title = ref("");
const author = ref("");

const { result, loading, error, refetch } = useQuery(GET_BOOKS);
const { mutate: createBook } = useMutation(CREATE_BOOK);

/* ---------- Action ---------- */

const addBook = async () => {
  if (!title.value || !author.value) return;

  await createBook({
    title: title.value,
    author: author.value
  });

  title.value = "";
  author.value = "";
  refetch();
};
</script>

<template>
  <div>
    <h2>Books</h2>

    <!-- Inputs -->
    <input v-model="title" placeholder="Title" />
    <input v-model="author" placeholder="Author" />
    <button @click="addBook">Add</button>

    <p v-if="loading">Loading...</p>
    <p v-if="error">Error: {{ error.message }}</p>

    <ul v-if="result?.books">
      <li v-for="b in result.books" :key="b.id">
        {{ b.title }} — {{ b.author }}
      </li>
    </ul>
  </div>
</template>
