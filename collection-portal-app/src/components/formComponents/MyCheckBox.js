import { useField } from "formik";

const MyCheckBox = ({ name, label, ...props }) => {
  const [field, meta] = useField({ ...props, name, type: 'checkbox' });
  return (
    <div className="d-flex flex-column justify-content-center align-items-center form-check">
      <label htmlFor={name} className="form-check-label fs-4 m-2">{label}</label>
      <input id={name} className="form-check-input" type="checkbox" {...{...props, name}}{...field} />
      {meta.touched && meta.error ? (
        <div className="error">{meta.error}</div>
      ) : null}
    </div>
  )
}

export default MyCheckBox