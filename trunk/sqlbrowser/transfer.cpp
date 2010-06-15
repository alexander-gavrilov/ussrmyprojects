#include "transfer.h"
#include "ui_transfer.h"

Transfer::Transfer(QWidget *parent, QAbstractItemModel *source_model) :
    QDialog(parent),
    ui(new Ui::Transfer)
{
    ui->setupUi(this);
    ui->connectionWidget->refresh();
    ui->tableView->setModel(source_model);

}

Transfer::~Transfer()
{
    delete ui;
}

void Transfer::changeEvent(QEvent *e)
{
    QDialog::changeEvent(e);
    switch (e->type()) {
    case QEvent::LanguageChange:
        ui->retranslateUi(this);
        break;
    default:
        break;
    }
}
