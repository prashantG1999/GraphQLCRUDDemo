import { gql } from "@apollo/client/core";

export const GET_BOOKS = gql`
  query {
    books {
      id
      title
      author
    }
  }
`;

export const CREATE_BOOK = gql`
  mutation ($title: String!, $author: String!) {
    createBook(title: $title, author: $author) {
      id
    }
  }
`;

export const UPDATE_BOOK = gql`
  mutation ($id: Int!, $title: String!, $author: String!) {
    updateBook(id: $id, title: $title, author: $author) {
      id
    }
  }
`;

export const DELETE_BOOK = gql`
  mutation ($id: Int!) {
    deleteBook(id: $id)
  }
`;
