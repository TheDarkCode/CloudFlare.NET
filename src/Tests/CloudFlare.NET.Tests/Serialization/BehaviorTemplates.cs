﻿namespace CloudFlare.NET.Serialization
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Machine.Specifications;
    using Newtonsoft.Json.Linq;

    [Behaviors]
    public class IdentifierSerializeBehavior
    {
        protected static JObject _json;
        protected static IIdentifier _sut;

        It should_serialize_id = () => _sut.Id.ToString().ShouldEqual(_json["id"].Value<string>());
    }

    [Behaviors]
    public class IdentifierDeserializeBehavior
    {
        protected static JObject _json;
        protected static IIdentifier _sut;

        It should_deserialize_id = () => _sut.Id.ToString().ShouldEqual(_json["id"].Value<string>());
    }

    [Behaviors]
    public class ModifiedDeserializeBehavior
    {
        protected static JObject _json;
        protected static IModified _sut;

        It should_deserialize_created_on = () => _sut.CreatedOn.ShouldEqual(_json["created_on"].Value<DateTime>());

        It should_deserialize_modified_on = () => _sut.ModifiedOn.ShouldEqual(_json["modified_on"].Value<DateTime>());
    }

    [Behaviors]
    public class ModifiedSerializeBehavior
    {
        protected static JObject _json;
        protected static IModified _sut;

        It should_serialize_created_on =
            () => _sut.CreatedOn.Value.UtcDateTime.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss.FFFFFFFK")
                .ShouldEqual(_json["created_on"].Value<string>());

        It should_serialize_created_on_for_ISO8601 = () => _json["created_on"].ToString().ShouldEndWith("Z");

        It should_serialize_modified_on =
            () => _sut.ModifiedOn.UtcDateTime.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss.FFFFFFFK")
                .ShouldEqual(_json["modified_on"].Value<string>());

        It should_serialize_modified_on_for_ISO8601 = () => _json["modified_on"].ToString().ShouldEndWith("Z");
    }

    [Behaviors]
    public class ZoneSettingDeserializeBehavior
    {
        protected static JObject _json;
        protected static ZoneSettingBase _sut;

        It should_deserialize_id = () => _sut.Id.ShouldEqual(_json["id"].Value<string>());

        It should_deserialize_editable = () => _sut.Editable.ShouldEqual(_json["editable"].Value<bool>());

        It should_deserialize_modified_on = () => _sut.ModifiedOn.ShouldEqual(_json["modified_on"].Value<DateTime>());
    }

    [Behaviors]
    public class ZoneSettingSerializeBehavior
    {
        protected static JObject _json;
        protected static ZoneSettingBase _sut;

        It should_serialize_id = () => _sut.Id.ShouldEqual(_json["id"].Value<string>());

        It should_serialize_editable = () => _sut.Editable.ShouldEqual(_json["editable"].Value<bool>());

        It should_serialize_modified_on =
            () => _sut.ModifiedOn.GetValueOrDefault().UtcDateTime.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss.FFFFFFFK")
                .ShouldEqual(_json["modified_on"].Value<string>());

        It should_serialize_modified_on_for_ISO8601 = () => _json["modified_on"].ToString().ShouldEndWith("Z");
    }

    [Behaviors]
    public class PagedParametersSerializeBehavior<TOrder>
        where TOrder : struct
    {
        protected static JObject _json;
        protected static PagedParameters<TOrder> _sut;

        It should_serialize_id = () => _sut.Page.ShouldEqual(_json["page"].Value<int>());

        It should_serialize_per_page = () => _sut.PerPage.ShouldEqual(_json["per_page"].Value<int>());

        It should_serialize_order = () => _sut.Order.ToString().ShouldEqual(_json["order"].Value<string>());

        It should_serialize_direction =
            () => _sut.Direction.ToString().ShouldEqual(_json["direction"].Value<string>());

        It should_serialize_match = () => _sut.Match.ToString().ShouldEqual(_json["match"].Value<string>());
    }

    [Behaviors]
    public class PagedParametersKvpBehavior<TOrder>
        where TOrder : struct
    {
        protected static PagedParameters<TOrder> _parameters;
        protected static IReadOnlyDictionary<string, string> _result;

        It should_have_page_value = () => _result["page"].ShouldEqual(_parameters.Page.ToString());

        It should_have_per_page_value = () => _result["per_page"].ShouldEqual(_parameters.PerPage.ToString());

        It should_have_order_value = () => _result["order"].ShouldEqual(_parameters.Order.ToString());

        It should_have_direction_value = () => _result["direction"].ShouldEqual(_parameters.Direction.ToString());

        It should_have_match_value = () => _result["match"].ShouldEqual(_parameters.Match.ToString());
    }
}
