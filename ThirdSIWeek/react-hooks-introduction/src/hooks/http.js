import { useState, useEffect } from "react";

export const useHttp = (url, dependencies) => {
  const [isLoading, setIsLoading] = useState(false);
  const [data, setData] = useState(null);
  // fetch("https://swapi.co/api/people")
  useEffect(() => {
    fetch(url)
      .then(response => {
        if (!response.ok) {
          throw new Error("Failed to fetch.");
        }
        return response.json();
      })
      .then(charData => {
        const selectedCharacters = charData.results.slice(0, 5);
        setIsLoading(false);
        setLoadedChars(
          selectedCharacters.map((char, index) => ({
            name: char.name,
            id: index + 1
          }))
        );
      })
      .catch(err => {
        console.log(err);
        setIsLoading(false);
      })
      .then(response => {
        if (!response.ok) {
          throw new Error("Failed to fetch.");
        }
        return response.json();
      })
      .then(charData => {
        // const selectedCharacters = charData.results.slice(0, 5);
        // setIsLoading(false);
        // setLoadedChars(
        //   selectedCharacters.map((char, index) => ({
        //     name: char.name,
        //     id: index + 1
        //   }))
        // );
        setIsLoading(false);
        setData(data);
      })
      .catch(err => {
        console.log(err);
        setIsLoading(false);
      });
  }, dependencies);

  return [isLoading, data];
};
