import { useField } from "formik";
import { useTranslation } from "react-i18next";

const MySelect = ({ label, options, ...props }) => {
  const [field, meta] = useField(props)
  const { t } = useTranslation()
  return (
    <div className="d-flex flex-column justify-content-center align-items-center form-group">
      <label className="m-2 fs-4" htmlFor={props.name}>{label}</label>
      <select className="form-control" id={props.name} {...props} {...field} >
        <option hidden>{t('Select one')}</option>
        {options.map(option => (
          <option value={option.id} key={option.id}>{option.name}</option>
        ))}
      </select>
      {meta.touched && meta.error ? (
        <div className="text-danger">{meta.error}</div>
      ) : null}
    </div>
  )
}

export default MySelect