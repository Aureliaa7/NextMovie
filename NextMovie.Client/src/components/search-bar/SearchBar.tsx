import React, { useState } from 'react';
import { Form, InputGroup } from 'react-bootstrap';
import 'bootstrap-icons/font/bootstrap-icons.css';

interface SearchBarProps {
  onSearch: (query: string) => void;
  onReset: () => void;
}

const SearchBar: React.FC<SearchBarProps> = ({ onSearch, onReset }) => {
  const [query, setQuery] = useState('');

  const handleSearchChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setQuery(e.target.value);
  };

  const handleSearchSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    onSearch(query);
  };

  return (
    <Form onSubmit={handleSearchSubmit} className="mb-5">
      <InputGroup>
        <Form.Control
          type="text"
          placeholder="Search for a movie..."
          value={query}
          onChange={handleSearchChange}
          className="w-50"
        />
        <span>
          <button
            type="submit"
            className="btn btn-primary"
            style={{ backgroundColor: '#B8D8D8', border: 'none' }}
          >
            <i className="bi bi-search" style={{ fontSize: '20px' }}></i>
          </button>
          <button
            type="button"
            onClick={onReset}
            className="btn btn-secondary ms-2"
            style={{ backgroundColor: '#B8D8D8', border: 'none' }}
          >
            <i className="bi bi-arrow-repeat" style={{ fontSize: '20px' }}></i>
          </button>
        </span>
      </InputGroup>
    </Form>
  );
};

export default SearchBar;
