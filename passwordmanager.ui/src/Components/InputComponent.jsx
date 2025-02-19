// eslint-disable-next-line react/prop-types
function InputComponent({ label, name, type, value, onChange }) {
  return (
      <>
          <div className="mt-3">
              <label>{label}</label>
              <input type={type} name={name} value={value} onChange={onChange} />
          </div>
      </>
  );
}

export default InputComponent;