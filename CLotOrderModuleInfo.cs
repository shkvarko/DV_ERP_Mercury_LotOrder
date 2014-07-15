using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERPMercuryLotOrder
{
    public class CLotOrderModuleClassInfo : UniXP.Common.CModuleClassInfo
    {
        public CLotOrderModuleClassInfo()
        {
            UniXP.Common.CLASSINFO objClassInfo;

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryLotOrder.ChargeseEditor";
            objClassInfo.strName = "Доп. расходы";
            objClassInfo.strDescription = "Журнал дополнительных расходов";
            objClassInfo.lID = 0;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_DELIVERLIST_SMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryLotOrder.LotOrderListEditor";
            objClassInfo.strName = "Заказы";
            objClassInfo.strDescription = "Журнал заказов";
            objClassInfo.lID = 1;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_DELIVERLIST_SMALL";
            m_arClassInfo.Add(objClassInfo);

            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ERPMercuryLotOrder.LotListEditor";
            objClassInfo.strName = "Приходы на склад";
            objClassInfo.strDescription = "Журнал приходов на склад";
            objClassInfo.lID = 2;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_DELIVERLIST_SMALL";
            m_arClassInfo.Add(objClassInfo);
        }
    }

    public class CLotOrderModuleInfo : UniXP.Common.CClientModuleInfo
    {
        public CLotOrderModuleInfo()
            : base(Assembly.GetExecutingAssembly(),
                UniXP.Common.EnumDLLType.typeItem,
                new System.Guid("{AD971672-7E6E-48AC-BB09-0B067EEEB566}"),
                new System.Guid("{A6319AD0-08C0-49ED-B25B-659BAB622B15}"),
                ERPMercuryLotOrder.Properties.Resources.IMAGES_LOTORDER_SMALL,
                ERPMercuryLotOrder.Properties.Resources.IMAGES_LOTORDER_SMALL)
        {
        }

        /// <summary>
        /// Выполняет операции по проверке правильности установки модуля в системе.
        /// </summary>
        /// <param name="objProfile">Профиль пользователя.</param>
        public override System.Boolean Check(UniXP.Common.CProfile objProfile)
        {
            return true;
        }
        /// <summary>
        /// Выполняет операции по установке модуля в систему.
        /// </summary>
        /// <param name="objProfile">Профиль пользователя.</param>
        public override System.Boolean Install(UniXP.Common.CProfile objProfile)
        {
            return true;
        }
        /// <summary>
        /// Выполняет операции по удалению модуля из системы.
        /// </summary>
        /// <param name="objProfile">Профиль пользователя.</param>
        public override System.Boolean UnInstall(UniXP.Common.CProfile objProfile)
        {
            return true;
        }
        /// <summary>
        /// Производит действия по обновлению при установке новой версии подключаемого модуля.
        /// </summary>
        /// <param name="objProfile">Профиль пользователя.</param>
        public override System.Boolean Update(UniXP.Common.CProfile objProfile)
        {
            return true;
        }
        /// <summary>
        /// Возвращает список доступных классов в данном модуле.
        /// </summary>
        public override UniXP.Common.CModuleClassInfo GetClassInfo()
        {
            return new CLotOrderModuleClassInfo();
        }
    }

    public class ModuleInfo : PlugIn.IModuleInfo
    {
        public UniXP.Common.CClientModuleInfo GetModuleInfo()
        {
            return new CLotOrderModuleInfo();
        }
    }
}
