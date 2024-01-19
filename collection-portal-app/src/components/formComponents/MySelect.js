import { useField } from "formik";

const MySelect = ({ label, options, ...props }) => {
  const [field, meta] = useField(props);
  return (
    <div className="d-flex flex-column justify-content-center align-items-center form-group">
      <label className="m-3 fs-3" htmlFor={props.name}>{label}</label>
      <select className="form-control" id={props.name} {...props} {...field} >
        <option hidden>Select one</option>
        {options.map(option => (
          <option value={option.id} key={option.id}>{option.name}</option>
        ))}
      </select>
      {meta.touched && meta.error ? (
        <div className="text-error">{meta.error}</div>
      ) : null}
    </div>
  )
}

export default MySelect