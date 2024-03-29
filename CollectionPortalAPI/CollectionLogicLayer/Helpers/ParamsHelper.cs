﻿using CollectionDataLayer.Helpers;

namespace CollectionLogicLayer.Helpers;

internal static class ParamsHelper
{
    internal static QueryParams ConvertPaginationParamsToQuery(PaginationParams paginationParams)
    {
        return new QueryParams
        {
            Skip = (paginationParams.PageNumber - 1) * paginationParams.PageSize,
            Take = paginationParams.PageSize,
            OrderBy = paginationParams.OrderBy ?? "id",
            OrderType = paginationParams.OrderType ?? "desc"
        };
    }
}
