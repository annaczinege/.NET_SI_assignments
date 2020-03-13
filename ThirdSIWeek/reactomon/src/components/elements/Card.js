import styled from "styled-components";

export default styled.div`
  background-color: whitesmoke;
  box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2);
  transition: 0.3s;
  display: inline-block;
  &:hover {
    box-shadow: 0 12px 24px 0 rgba(0, 0, 0, 0.2);
  }
`;
