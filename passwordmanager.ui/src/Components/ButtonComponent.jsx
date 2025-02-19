// eslint-disable-next-line react/prop-types
function ButtonComponent({ type, name, onClick }) {
  return (
      <>
          <button  type={type} onClick={onClick} >
              { name }
          </button>
      </>
  );
}

export default ButtonComponent;