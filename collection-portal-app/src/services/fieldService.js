import { FIELD_TYPE_CHECKBOX, FIELD_TYPE_DATE, FIELD_TYPE_NUMBER, FIELD_TYPE_STRING, FIELD_TYPE_TEXT } from "../constants"

export default function getFieldWithNames(collection) {
  const fieldNames = {}
  for (let i = 1; i <= 3; i++) {
    for (const type in [FIELD_TYPE_TEXT, FIELD_TYPE_STRING, FIELD_TYPE_NUMBER, FIELD_TYPE_DATE, FIELD_TYPE_CHECKBOX]) {
      if (collection[`custom${type}${i}State`]) {
        fieldNames[`custom${type}${i}`] = {
          name: collection[`custom${type}${i}Name`],
          type
        }
      }
    }
  }
  return fieldNames
}