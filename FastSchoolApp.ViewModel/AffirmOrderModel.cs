using System;
using System.Windows.Input;

namespace FastSchoolApp.ViewModel
{
    public class AffirmOrderModel : BindableObject
    {
        public AffirmOrderModel()
        {
            ItemCommand = new Command(model =>
            {
                //var entiy =model as Commodity

            });
            //从这里获取数据源

        }
        public ICommand ItemCommand { get; private set; }

        public BindableProperty OrderNumberProperty = BindableProperty.Create("OrderNumber",
        typeof(string),
        typeof(AffirmOrderModel));

        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNumber
        {
            get { return (string)GetValue(OrderNumberProperty); }
            set { SetValue(OrderNumberProperty, value); }
        }



        public BindableProperty GetGoodsCodeProperty = BindableProperty.Create("GetGoodsCode",
            typeof(int),
            typeof(AffirmOrderModel),
            new Random().Next(10000, 99999));

        /// <summary>
        /// 取货码
        /// </summary>
        public int GetGoodsCode
        {
            get { return (int)GetValue(GetGoodsCodeProperty); }
            set { SetValue(GetGoodsCodeProperty, value); }
        }


        public BindableProperty GetGoodsAddressProperty = BindableProperty.Create(
            "GetGoodsAddress",
            typeof(string),
            typeof(AffirmOrderModel));
        /// <summary>
        /// 取货地点
        /// </summary>
        public string GetGoodsAddress
        {
            get { return GetValue(GetGoodsAddressProperty).ToString(); }
            set { SetValue(GetGoodsAddressProperty, value); }
        }

        public BindableProperty SendAddressProperty = BindableProperty.Create(
       "SendAddress",
       typeof(string),
       typeof(AffirmOrderModel));
        /// <summary>
        /// 收货地址
        /// </summary>
        public string SendAddress
        {
            get { return GetValue(SendAddressProperty).ToString(); }
            set { SetValue(SendAddressProperty, value); }
        }

        public BindableProperty OrderStatusProperty = BindableProperty.Create(
    "OrderStatus",
    typeof(OrderStatusEnum),
    typeof(AffirmOrderModel), OrderStatusEnum.下单成功);
        /// <summary>
        /// 订单状态
        /// </summary>
        public OrderStatusEnum OrderStatus
        {
            get { return (OrderStatusEnum)GetValue(SendAddressProperty); }
            set { SetValue(SendAddressProperty, value); }
        }
    }
}
