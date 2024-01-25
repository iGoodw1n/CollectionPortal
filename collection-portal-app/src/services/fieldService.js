import { FIELD_TYPE_CHECKBOX, FIELD_TYPE_DATE, FIELD_TYPE_NUMBER, FIELD_TYPE_STRING, FIELD_TYPE_TEXT } from "../constants"

export default function getFieldWithNames(collection) {
  const fieldNames = {}
  for (let index = 1; index <= 3; index++) {
    for (const type of [FIELD_TYPE_TEXT, FIELD_TYPE_STRING, FIELD_TYPE_NUMBER, FIELD_TYPE_DATE, FIELD_TYPE_CHECKBOX]) {
      if (collection[`custom${type}${index}State`]) {
        fieldNames[`custom${type}${index}`] = {
          name: collection[`custom${type}${index}Name`],
          type
        }
      }
    }
  }
  return fieldNames
}