import React, { Component, useEffect, useState } from "react";
import axiosInstance from "../../axiosInstance";
import { NewsDto } from "../../models/models";
import TextField from "@material-ui/core/TextField";
import _ from "lodash";
import "../../CSS/news.scss";

const News = () => {
  const [loading, setLoading] = useState(true);
  const [news, setNews] = useState<NewsDto | null>(null);
  const [searchTerm, setSearchTerm] = useState("news");
  const handleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setSearchTerm(event.target.value);
  };

  useEffect(() => {
    axiosInstance
      .get("api/news/GetNews", {
        params: {
          searchTerm: searchTerm,
        },
      })
      .then((res) => {
        setNews(res.data);
        setLoading(false);
      });
  }, [searchTerm]);

  return loading ? (
    <p>
      <em>Loading...</em>
    </p>
  ) : (
    <>
      <TextField
        id="outlined-name"
        className="search-field"
        label="searchTerm"
        value={searchTerm}
        onChange={handleChange}
        variant="outlined"
      />
      <table className="table table-striped" aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Title</th>
            <th>Author</th>
            <th>Description</th>
          </tr>
        </thead>
        <tbody>
          {news?.articles?.map((article, idx) => (
            <tr key={idx}>
              <td>{article.title}</td>
              <td>
                {article.author}
                <br />
                <a href={article.url} target="_blank">{article.url?.split(".com")[0]}</a>
              </td>
              <td>{article.description}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </>
  );
};

export { News };
