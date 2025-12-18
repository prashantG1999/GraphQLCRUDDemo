import { ApolloClient, InMemoryCache } from "@apollo/client/core";
import { createHttpLink } from "@apollo/client/link/http";

export const apolloClient = new ApolloClient({
  link: createHttpLink({
    uri: "https://localhost:7185/graphql"
  }),
  cache: new InMemoryCache()
});
